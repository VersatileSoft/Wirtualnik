import { AxiosStatic } from 'axios';
import { Product } from '~/models/Product';

export default class CartService {
    private axios: AxiosStatic;

    constructor(axios: AxiosStatic) {
        this.axios = axios;
    }

    public async getCart(): Promise<DetailsModel> {
        try {
            return (await this.axios.get<DetailsModel>('cart')).data;
        } catch (e) {
            console.log(e);
        }
        return {} as DetailsModel;
    }

    public async addToCart(productId: string): Promise<DetailsModel> {
        return (await this.axios.post<DetailsModel>(`cart/add/${productId}`))
            .data;
    }

    public async getWarnings(): Promise<WarningModel[]> {
        return (await this.axios.get<WarningModel[]>(`cart/warnings`)).data;
    }
}

export interface DetailsModel {
    quantity: number;
    temporaryId: string;
    products: Product[];
}

export interface WarningModel {
    title: string;
    message: string;
    image: number;
    type: string;
}
