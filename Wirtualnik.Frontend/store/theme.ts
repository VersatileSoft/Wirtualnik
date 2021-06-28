interface ThemeState {
  theme: string
}

export const state = (): ThemeState => ({
  theme: 'light',
})

export const mutations = {
  CHANGE_THEME(state: ThemeState, theme: string) {
    state.theme = theme
  },
}
