import toastr from 'toastr';

const type = "toastrAction";

export {
  type
};

export function invoke(data) {
  toastr[data.toastType](data.message, data.title);

  return {
    type,
    fetching: false,
    err: false
  };
}

