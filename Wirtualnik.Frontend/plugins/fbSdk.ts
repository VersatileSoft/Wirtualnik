window.fbAsyncInit = () => {
  const appId = process.env.VUE_APP_FACEBOOK_APP_ID
  FB.init({
    appId,
    cookie: true,
    xfbml: true,
    version: 'v2.8',
  })
  FB.getLoginStatus((obj) => {
    if (obj.authResponse) {
      console.log(obj)
    }
  })
  FB.AppEvents.logPageView()
}
