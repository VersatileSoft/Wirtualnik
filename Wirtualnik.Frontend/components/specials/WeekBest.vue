<template>
  <div class="week-best product-card">
    <div class="week-best__image glow-cyan">
      <slot name="image"></slot>
    </div>
    <div class="product-card__card-title">
      <slot name="creator"></slot>
    </div>
    <div class="product-card__product-price">
      <slot name="price"></slot>
    </div>
    <div class="product-card__quote">
      <slot name="quote"></slot>
    </div>
    <div class="week-best__part-list">
      <slot name="parts"></slot>
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
.week-best {
  min-width: 155px;
  margin: 3px;
  max-width: 100%;
  background: linear-gradient(
    0deg,
    var(--white) 0%,
    var(--transparent) 50%,
    var(--white) 80%
  );
  flex: 1 1 42%;
  padding: 12px;
  border-radius: 15px;
  animation: fadeIn 0.3s ease-in;
  box-shadow: var(--shadowcard);
  transition: all 0.2s ease-out;
  color: var(--black);
  height: max-content;
  margin-bottom: 60px !important;
  &::before {
    content: '👑 WIRTUALNIK TYGODNIA';
    color: var(--white);
    background: linear-gradient(
      90deg,
      rgba(231, 71, 71, 1) 0%,
      rgba(230, 51, 120, 1) 100%
    );
    padding: 6px 12px;
    margin: -12px 0 0 -12px;
    border-radius: 15px 0 5px 0;
    width: fit-content;
    display: block;
    font-weight: 400;
  }
  &__image {
    margin-left: -12px;
    width: 100%;
    max-height: 227px;
    padding: 12px;
  }
  &__part-list {
    border-radius: 0;
    display: flex;
    flex-direction: column;
    margin-left: -12px;
    margin-right: -12px;
  }
  &__part-list > div {
    padding: 12px 10px;
    margin: 0;
    display: flex;
    align-items: center;
    &:nth-child(even) {
      background-color: var(--gray1);
    }
  }
  &__part-list div > p {
    display: flex;
    align-items: center;
    min-width: 120px;
    justify-content: flex-end;
    flex-grow: 1;
  }
  &__part-list img {
    width: 20px;
    max-height: 30px;
    margin-left: 10px;
    margin-right: 10px;
  }
}
.glow-cyan {
  background: radial-gradient(
    ellipse at center,
    rgba(40, 176, 240, 0.15) 20%,
    rgba(255, 255, 255, 0) 70%
  );
}
</style>
