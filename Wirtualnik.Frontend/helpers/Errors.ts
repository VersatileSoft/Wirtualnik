import { ErrorBag } from 'vee-validate'

class Errors {
  private errors: Record<string, string[]>

  /**
   * Create a new Errors instance.
   */
  public constructor(errors: Record<string, string[]> = {}) {
    this.record(errors)
  }

  /**
   * Get all the errors.
   */
  public all(): Record<string, string[]> {
    return this.errors
  }

  /**
   * Determine if any errors exists for the given field or object.
   */
  public has(field: string): boolean {
    return this.errors.hasOwnProperty(field.toLowerCase()) //eslint-disable-line
  }

  public state(field: string): boolean {
    return !this.has(field)
  }

  public first(field: string): string {
    return this.get(field)[0]
  }

  public get(field: string): string[] {
    return this.errors[field.toLowerCase()] || []
  }

  public push(field: string, error: string): void {
    const errors: Record<string, string[]> = {}
    const messages = this.get(field.toLowerCase())

    messages.push(error)
    errors[field.toLowerCase()] = messages

    this.errors = Object.assign({}, this.errors, errors)
  }

  /**
   * Determine if we have any errors.
   */
  public any(): boolean {
    return Object.keys(this.errors).length > 0
  }

  /**
   * Record the new errors.
   */
  public record(errors: Record<string, string[]>): void {
    this.errors = {}

    Object.keys(errors).forEach(
      (field) => (this.errors[field.toLowerCase()] = errors[field])
    )
  }

  /**
   * Record the new errors from ErrorBag
   */
  public validation(errors: ErrorBag): void {
    errors.items.forEach((p) => {
      this.push(p.field, p.msg)
    })
  }

  /**
   * Clear a specific field, object or all error fields.
   */
  public clear(field?: string): void {
    if (!field) {
      this.errors = {}
      return
    }

    Object.keys(this.errors)
      .filter((e) => e === field.toLowerCase())
      .forEach((e) => delete this.errors[e])
  }
}

export default Errors
