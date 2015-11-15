const type = "setCustomerPropertyAction";

const context = "customer";

export {
  type, context
};

export function invoke(name, value) {

  let data = {};
  data[name] = value;

  return {
    context,
    type,
    data
  };
}

