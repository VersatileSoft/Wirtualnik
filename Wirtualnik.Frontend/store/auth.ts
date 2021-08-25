interface AuthState {
    token: string;
    givenName: string;
    surname: string;
    picture: string;
}

export const state = (): AuthState => ({
    token: '',
    givenName: '',
    surname: '',
    picture: '',
});

export const mutations = {
    SET_TOKEN(state: AuthState, token: string) {
        state.token = token;
    },

    SET_GIVEN_NAME(state: AuthState, givenName: string) {
        state.givenName = givenName;
    },

    SET_SURNAME(state: AuthState, surname: string) {
      state.surname = surname;
    },

    SET_PICTURE(state: AuthState, picture: string) {
      state.picture = picture;
    }
};
