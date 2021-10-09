import { DetailsModel } from '../services/CartService';

export interface CartState {
    currentCart: DetailsModel | null;
}

export const state = (): CartState => ({
    currentCart: null
});

export const mutations = {
    setCurrentCart(state: CartState, currentCart: DetailsModel): void {
        state.currentCart = currentCart;
    }
};
