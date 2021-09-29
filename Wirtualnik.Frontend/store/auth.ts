import { AuthModel } from '../services/AuthService';

export interface AuthState {
    loaded: boolean;
    authenticated: boolean;
    token: string;
    identity: AuthModel | null;
    rememberMe: boolean;
}

export const state = (): AuthState => ({
    loaded: false,
    authenticated: false,
    identity: null,
    rememberMe: false,
    token: ''
});

export const mutations = {
    setLoaded(state: AuthState, value: boolean): void {
        state.loaded = value;
    },
    setAuthenticated(state: AuthState, value: boolean): void {
        state.authenticated = value;
    },
    setIdentity(state: AuthState, identity: AuthModel): void {
        state.identity = identity;
    },
    clearIdentity(state: AuthState): void {
        state.identity = null;
    },
    rememberMe(state: AuthState, enabled: boolean): void {
        state.rememberMe = enabled;
    },
    setToken(state: AuthState, token: string): void {
        state.token = token;
    }
};
