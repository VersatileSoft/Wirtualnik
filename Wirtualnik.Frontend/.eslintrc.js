module.exports = {
  root: true,
  env: {
    browser: true,
    node: true,
  },
  extends: [
    '@nuxtjs/eslint-config-typescript',
    'plugin:prettier/recommended',
    'plugin:nuxt/recommended',
  ],
  'prettier/prettier': [
    'error',
    {
      endOfLine: 'auto',
    },
  ],
  plugins: [],
  // add your custom rules here
  rules: {},
}
