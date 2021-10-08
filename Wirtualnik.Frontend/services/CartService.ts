import { AxiosStatic } from 'axios';
import { Product } from '~/models/Product';

export default class CartService {
    private axios: AxiosStatic;

    constructor(axios: AxiosStatic) {
        this.axios = axios;
    }

    public async getCart(): Promise<DetailsModel> {
        return (await this.axios.get<DetailsModel>('cart')).data;
    }

    public async addToCart(productId: string): Promise<DetailsModel> {
        return (await this.axios.post<DetailsModel>(`cart/add/${productId}`))
            .data;
    }
}

export interface DetailsModel {
    quantity: number;
    temporaryId: string;
    products: Product[];
}
