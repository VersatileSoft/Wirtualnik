<template>
  <div class="product-card">
    <div class="product-card__card-image product-card__image-glow-orange">
      <slot name="image"></slot>
    </div>
    <div class="product-card__card-title">
      <slot name="title"></slot>
    </div>
    <div class="product-card__product-price">
      <slot name="price"></slot>
    </div>
    <div class="product-card__product-short-specs">
      <slot name="specs"></slot>
    </div>
    <div class="product-card__card-controls">
      <div class="product-card__product-points-red product-card__points-box">
        <slot name="red-points"></slot>
      </div>
      <div class="product-card__product-points-blue product-card__points-box">
        <slot name="blue-points"></slot>
      </div>
      <div class="product-card__buttons">
        <slot name="buttons"></slot>
      </div>
    </div>
  </div>
</template>

<style lang="scss">
.product-card {
  flex: 1 1 42%;
  min-width: 240px;
  padding: 12px;
  background: linear-gradient(
    0deg,
    var(--white) 0%,
    var(--white) 50%,
    var(--transparent) 80%
  );
  border-radius: 15px;
  box-shadow: var(--shadowcard);
  animation: fadeIn 0.3s ease-in;
  color: var(--black);
  transition: all 0.2s ease-out;
  height: max-content;
  &__card-image {
    max-height: 227px;
    padding: 12px;
    background: radial-gradient(
      ellipse at center,
      rgba(240, 105, 40, 0.2) 20%,
      rgba(255, 255, 255, 0) 70%
    );
  }
  &__card-title {
    margin-top: 10px;
    h2 {
      font-size: 16px;
      line-height: 18px;
    }
  }
  &__product-price {
    display: flex;
    margin-top: -8px;
    align-items: center;
    h4 {
      line-height: 0px;
      font-size: 14px;
      font-weight: 400;
      color: var(--gray4);
    }
    img {
      max-height: 16px;
      margin-left: 5px;
    }
  }
  &__quote {
    background-color: var(--white);
    padding: 15px;
    border-radius: 10px;
    margin: 7px 0;
  }
  &__product-short-specs {
    color: var(--gray6);
  }
  &__card-controls {
    display: flex;
    flex-wrap: wrap;
    justify-content: flex-start;
    width: calc(100% - 42px);
  }
  &__product-points-red {
    color: var(--red);
    background: radial-gradient(
      circle,
      rgba(255, 0, 0, 0.1) 0%,
      rgba(255, 255, 255, 0) 80%
    );
  }
  &__product-points-blue {
    color: var(--blue);
    background: radial-gradient(
      circle,
      rgba(0, 0, 255, 0.08) 0%,
      rgba(255, 255, 255, 0) 80%
    );
  }
  &__points-box {
    width: 50%;
    text-align: center;
    line-height: 5px;
    padding: 25px 0;
    margin: -5px 0;
    h5 {
      margin: 20px 0 0;
      font-size: 20px;
    }
  }
  &__buttons {
    display: flex;
    flex-direction: column;
    justify-content: flex-end;
    margin: 0 0 -6px auto;
    width: 42px;
    height: 0;
    position: relative;
    bottom: 5px;
    right: -38px;
    text-align: right;
  }
  p {
    font-size: 14px;
    margin: 0.5em 0 0.5em 0;
    line-height: 1;
  }
  a {
    color: var(--link);
    text-decoration: underline;
    text-decoration-color: var(--gray3);
  }
}
</style>
