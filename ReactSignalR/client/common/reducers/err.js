export default function err(err = null, action) {
  let newErr = err;

  if (!!action.err) {
    newErr = Object.assign({}, action.err);
  }

  return newErr;
}
