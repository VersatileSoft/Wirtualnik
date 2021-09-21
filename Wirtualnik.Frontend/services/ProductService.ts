import axios from 'axios';
import { Product } from '../models/Product';

export default class ProductService {
    public static async getProduct(id: string): Promise<Product> {
        try {
            const response = await axios.get<Product>(
                process.env.VUE_APP_API_URL_PRODUCT + id
            );
            return response.data;
        } catch (ex) {
            console.log(ex);
        }
    }

    public static async getProductsByType(type: string): Promise<Product> {
        try {
            const response = await axios.get<Product>(
                process.env.VUE_APP_API_URL_PRODUCT,
                {
                    params: {
                        ProductType: type
                    }
                }
            );
            return response.data.items;
        } catch (ex) {
            console.log(ex);
        }
    }

    public static async getProductsByCategory(category: string): Promise<Product> {
        try {
            const response = await axios.get<Product>(
                process.env.VUE_APP_API_URL_PRODUCT,
                {
                    params: {
                        typePublicId: category
                    }
                }
            );
            return response.data.items;
        } catch (ex) {
            console.log(ex);
        }
    }
}

