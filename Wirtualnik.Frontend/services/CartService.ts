import { AxiosStatic } from 'axios';
import { Product } from '~/models/Product';

export default class CartService {
    private axios: AxiosStatic;

    constructor(axios: AxiosStatic) {
        this.axios = axios;
    }

    public async getCart(
        temporaryId: string | null = null
    ): Promise<DetailsModel> {
        return (
            await this.axios.get<DetailsModel>('cart', {
                params: { temporaryId }
            })
        ).data;
    }

    public async addToCart(
        productId: string,
        temporaryId: string | null = null
    ): Promise<AddingResultModel> {
        console.log('service');
        return (
            await this.axios.post<AddingResultModel>(
                `cart/add/${productId}`,
                null,
                {
                    params: { temporaryId: temporaryId }
                }
            )
        ).data;
    }
}

export interface DetailsModel {
    products: Product[];
}

export interface CartSimpleModel {
    quantity: number;
    temporaryId: string;
    products: string[];
}

export interface AddingResultModel {
    temporaryId?: string;
    success: boolean;
    errors: string[];
    quantity: number;
    products: string[];
}
