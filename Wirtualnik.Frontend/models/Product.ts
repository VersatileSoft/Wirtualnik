import { ProductShopDetails } from './ProductShopDetails';

export interface Product {
    name: string;
    productTypeId: number;
    productTypeName: string;
    publicId: string;
    ean: string;
    sku: string;
    description: string;
    manufacturer: string;
    color: string;
    images: string[];
    properties: { [key: string]: string };
    productShopDetails: ProductShopDetails;
}
