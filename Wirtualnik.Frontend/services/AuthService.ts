import jwt_decode from 'jwt-decode';
import { AuthState } from '../store/auth';
import { Store } from 'vuex';

export interface Auth {
    login(): Promise<void>;
    logout(): void;
    token(): string;
    user(): AuthModel | null;
    check(): boolean;
}

export default class AuthService implements Auth {
    private store: Store<any>;

    public constructor(store: Store<any>) {
        this.store = store;
    }

    private get state(): AuthState {
        return this.store.state.auth as AuthState;
    }

    private setToken(tokens: TokenModel): void {
        if (tokens.token.length > 0) {
            this.store.commit('auth/setToken', tokens.token);
            this.store.commit('auth/setAuthenticated', true);
        }
    }

    private clearAll(): void {
        this.store.commit('auth/clearIdentity');
        this.store.commit('auth/setToken', null);
        this.store.commit('auth/setAuthenticated', false);
    }

    public async login(): Promise<void> {
        try {
            this.clearAll();
            const href = await this.showAuthWindow();
            const token = href.split('=')[1];

            const decoded: any = jwt_decode(token);

            this.store.commit('auth/setIdentity', {
                givenName: decoded.given_name,
                surname: decoded.family_name,
                email: '',
                id: 0,
                publicId: '',
                userName: ''
            });

            this.setToken({ token: token } as TokenModel);
        } catch (ex) {
            this.clearAll();
            throw ex;
        }
    }

    public logout(): void {
        this.clearAll();
    }

    public token(): string {
        return this.state.token;
    }

    public user(): AuthModel | null {
        return this.state.identity;
    }

    public check(): boolean {
        return this.state.authenticated;
    }

    private showAuthWindow(): Promise<string> {
        const temp = window.open(
            `${process.env.VUE_APP_API_AUTH_URL}login/Facebook`,
            'Logowanie',
            'location=0,status=0,width=700,height=900'
        );
        if (temp == null) {
            return Promise.reject('Window null');
        }
        const oauthWindow: Window = temp;

        return new Promise<string>((resolve, reject) => {
            const oauthInterval = window.setInterval(function () {
                if (oauthWindow.closed) {
                    clearInterval(oauthInterval);
                    reject('Window closed');
                }

                if (oauthWindow.location.href.includes('access_token')) {
                    clearInterval(oauthInterval);
                    oauthWindow.close();
                    resolve(oauthWindow.location.href);
                }
            }, 100);
        });
    }
}

export interface TokenModel {
    token: string;
    refresh: string;
    expires: string;
}

export interface AuthModel {
    id: number;
    publicId: string;
    userName: string;
    email: string;
    givenName: string;
    surname: string;
}
