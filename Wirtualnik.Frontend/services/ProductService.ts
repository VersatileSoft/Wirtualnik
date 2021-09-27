import { Product } from '../models/Product';
import { Pagination } from '../models/Pagination';
import { AxiosStatic } from 'axios';

export default class ProductService {
    private axios: AxiosStatic;

    constructor(axios: AxiosStatic) {
        this.axios = axios;
    }

    public async getProduct(id: string): Promise<Product> {
        return (await this.axios.get<Product>(process.env.VUE_APP_API_URL_DEFAULT + `product/${id}`)).data;
    }

    public async getProductsByCategory(
        category: string
    ): Promise<Pagination<Product>> {
        return (
            await this.axios.get<Pagination<Product>>(process.env.VUE_APP_API_URL_DEFAULT + 'product', {
                params: { productType: category }
            })
        ).data;
    }
}
