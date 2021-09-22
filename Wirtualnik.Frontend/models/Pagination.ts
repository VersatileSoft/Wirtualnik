export interface Pagination<T> {
    items: T[];
    meta: never;
    totalRows: number;
}
