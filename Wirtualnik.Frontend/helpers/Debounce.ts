export default function Debounce(milliseconds = 0, options = {}): any {
    return function (
        target: any,
        propertyKey: string,
        descriptor: PropertyDescriptor
    ) {
        const map = new WeakMap();
        const originalMethod = descriptor.value;

        descriptor.value = function (...args: any) {
            const vm = this;
            let debounced = map.get(this);

            if (debounced) {
                clearTimeout(debounced);
                map.delete(this);
            }

            debounced = setTimeout(function () {
                originalMethod.call(vm, ...args);
            }, milliseconds);

            map.set(this, debounced);
        };

        return descriptor;
    };
}
