import { Product } from '../models/Product';
import { Pagination } from '../models/Pagination';
import { AxiosStatic } from 'axios';
import Pager from '@/helpers/Pager';
import merge from 'lodash/merge';
import { FilterModel } from '@/models/FilterModel';

export default class ProductService {
    private axios: AxiosStatic;

    constructor(axios: AxiosStatic) {
        this.axios = axios;
    }

    public async getProduct(id: string): Promise<Product> {
        return (await this.axios.get<Product>(`product/${id}`)).data;
    }

    public async getProducts(
        pager: Pager,
        filter: FilterModel
    ): Promise<Pagination<Product>> {
        return (
            await this.axios.get<Pagination<Product>>('product', {
                params: merge(filter, pager.data())
            })
        ).data;
    }
}
