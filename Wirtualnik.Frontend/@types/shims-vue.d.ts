declare module 'global' {
  interface Vue {
    $mq: string
    phone: boolean
    tablet: boolean
    mobile: boolean
    laptop: boolean
    desktop: boolean
  }
}
