const type = "setValidityPropertyAction";
const context = "customer";

export {
  type,
  context
};

export function invoke(elementName, validity) {
  return {
    type,
    context,
    data: {
      elementName,
      validity
    }
  };
}
