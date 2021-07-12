interface AuthState {
  token: string
}

export const state = (): AuthState => ({
  token: '',
})

export const mutations = {
  SET_TOKEN(state: AuthState, token: string) {
    state.token = token
  },
}
