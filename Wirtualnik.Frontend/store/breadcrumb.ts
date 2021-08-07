export interface CrumbDetail {
  name: string
  route: string
}

interface CrumbState {
  breadcrumbs: CrumbDetail[]
}

export const state = (): CrumbState => ({
  breadcrumbs: [
    {
      name: 'Wirtualnik.pl',
      route: '/',
    },
  ],
})

export const mutations = {
  SET_BREADCRUMBS(state, breadcrumbs) {
    state.breadcrumbs = breadcrumbs
  },
}
