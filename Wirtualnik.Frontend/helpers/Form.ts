import merge from 'lodash/merge'
import Errors from './Errors'

class FormHelper<T extends Record<string, any>> {
  private $initial = {}

  public $loaded: boolean
  public $loading: boolean
  public $errors: Errors;

  [prop: string]: any

  /**
   * Create a new Form instance.
   */
  public constructor(data: T) {
    this.$loaded = false
    this.$loading = false
    this.$errors = new Errors()
    this.setInitialValues(data)
    this.withData(data).withErrors({})
  }

  public withData(data: T): FormHelper<T> {
    for (const field in data) {
      this[field as string] = data[field]
    }

    return this
  }

  public withErrors(errors: Record<string, string[]>): FormHelper<T> {
    this.$errors.record(errors)

    return this
  }

  /**
   * Fetch all relevant data for the form.
   */
  public data(): T {
    const data = {} as any

    for (const property in this.$initial) {
      data[property] = this[property] as any
    }

    return data as T
  }

  /**
   * Fetch only selected data for the form.
   */
  public only(props: string[]): any {
    const data = {} as any

    for (const property in this.$initial) {
      if (props.includes(property)) {
        data[property] = this[property] as any
      }
    }

    return data
  }

  /**
   * Fetch data for the form except selected.
   */
  public except(props: string[]): any {
    const data = {} as any

    for (const property in this.$initial) {
      if (!props.includes(property)) {
        data[property] = this[property] as any
      }
    }

    return data
  }

  /**
   * Reset the form fields.
   */
  public reset(): void {
    merge(this, this.$initial)

    this.$errors.clear()
    this.complete(true)
  }

  public setInitialValues(values: any): void {
    this.$initial = {}

    merge(this.$initial, values)
  }

  /**
   * Clear the form fields.
   */
  public clear(): void {
    for (const field in this.$initial) {
      this[field] = this.$initial[field]
    }

    this.$errors.clear()
  }

  public loading(): boolean {
    return !this.$loaded && this.$loading
  }

  public wait($forceLoading: boolean = false): void {
    if ($forceLoading) this.$loaded = false

    this.$loading = true
  }

  public continue(): void {
    this.complete(this.valid())
  }

  public complete(status: boolean = true): void {
    if (status === true) {
      this.$errors.clear()
    }

    this.$loading = false
    this.$loaded = true
  }

  public async ready(values: Promise<boolean>[]): Promise<void> {
    this.wait()
    const result = await Promise.all(values)
    this.complete(result.every((p) => p === true))
  }

  public valid(): boolean {
    return !this.$errors.any()
  }

  public active(): boolean {
    // return !this.$loading && this.valid();
    return !this.$loading
  }

  public static create<T>(data: T): FormHelper<T> {
    return new FormHelper<T>(data)
  }
}

type FormType<T> = FormHelper<T> & T

interface FormFactory {
  new <T>(data: T): FormType<T>
  create<T>(data: T): FormType<T>
}

const Form: FormFactory = FormHelper as any

export default Form
