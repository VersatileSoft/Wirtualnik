import { CartSimpleModel } from '../services/CartService';

export interface CartState {
    currentCart: CartSimpleModel | null;
}

export const state = (): CartState => ({
    currentCart: null
});

export const mutations = {
    setCurrentCart(state: CartState, currentCart: CartSimpleModel): void {
        state.currentCart = currentCart;
    }
};
