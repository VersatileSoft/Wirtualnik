export default class Pager {
    private $pageIndex = 0;
    private $pageSize = 10;
    private $sorting = '';
    private $order = 'ASC';
    private $totalRows = 0;

    /**
     * Create a new Pager instance.
     */
    public constructor(
        pageIndex: number,
        pageSize = 20,
        sorting = 'id',
        order = 'ASC'
    ) {
        this.setTotalRows(Number.MAX_SAFE_INTEGER);
        this.setPageSize(pageSize);
        this.setPageIndex(pageIndex);
        this.setSort(sorting, order);
    }

    public get pageIndex(): number {
        return this.getPageIndex();
    }

    public set pageIndex(value: number) {
        this.setPageIndex(value);
    }

    public get pageSize(): number {
        return this.getPageSize();
    }

    public set pageSize(value: number) {
        this.setPageSize(value);
    }

    public get sorting(): string {
        return this.getSort();
    }

    public set sorting(value: string) {
        this.setSort(value);
    }

    public get order(): string {
        return this.getOrder();
    }

    public set order(value: string) {
        this.setOrder(value);
    }

    public get totalRows(): number {
        return this.getTotalRows();
    }

    public set totalRows(value: number) {
        this.setTotalRows(value);
    }

    public get totalPages(): number {
        return this.getTotalPages();
    }

    public get offset(): number {
        return this.getOffset();
    }

    public setPageIndex(index: number): void {
        this.$pageIndex = !isNaN(index) && index > 0 ? index : 1;
    }

    public getPageIndex(): number {
        if (this.$pageIndex < this.getTotalPages()) return this.$pageIndex;
        else if (this.getTotalPages() > 0) return this.getTotalPages();
        else return 1;
    }

    public setPageSize(size: number): void {
        this.$pageSize = !isNaN(size) && size > 0 ? size : 10;
    }

    public getPageSize(): number {
        return this.$pageSize;
    }

    public sort(sorting: string): void {
        this.$sorting = sorting;
    }

    public setSort(sorting: string, order = 'ASC'): void {
        this.$sorting = sorting;
        this.setOrder(order);
    }

    public getSort(): string {
        return this.$sorting;
    }

    public setOrder(order: string): void {
        this.$order = order.toUpperCase() === 'ASC' ? 'ASC' : 'DESC';
    }

    public getOrder(): string {
        return this.$order;
    }

    public setTotalRows(rows: number): void {
        this.$totalRows = !isNaN(rows) && rows > 0 ? rows : 0;
    }

    public getTotalRows(): number {
        return this.$totalRows;
    }

    public getTotalPages(): number {
        if (this.getPageSize() > 0)
            return Math.ceil(this.getTotalRows() / this.getPageSize());
        else return 0;
    }

    public getOffset(): number {
        return (this.getPageIndex() - 1) * this.getPageSize();
    }

    public data(): PagerContract {
        return {
            pageIndex: this.getPageIndex(),
            pageSize: this.getPageSize(),
            sort: this.getSort(),
            order: this.getOrder()
        };
    }
}

interface PagerContract {
    pageIndex: number;
    pageSize: number;
    sort: string;
    order: string;
}
