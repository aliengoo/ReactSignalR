"use strict";

import React, {Component, PropTypes} from 'react';
import Rx from 'rx';

export default class Form extends Component {

  constructor() {
    super();
    this.streamsMap = {};
  }
  componentDidMount() {
    const {setValidityProperty} = this.props;

    this.formElement = document.querySelector(`form[name="${this.props.name}"]`);

    const children = this.formElement.querySelectorAll('input, select, textarea');

    for(let i = 0; i < children.length; i++) {
      const el = children[i];
      const name = el.getAttribute("name");
      this.streamsMap[name] =
        Rx.Observable.fromEvent(el, "keyup").debounce(500).subscribe(() => {
          el.checkValidity();
          setValidityProperty(name, el.validity);
        });
    }
  }

  componentWillUnmount() {
    for(let key in this.streamsMap) {
      this.streamsMap[key].unsubscribe();
    }
  }

  render() {
    const {children, name} = this.props;
    return (
      <form name={name}>
        {children}
      </form>);
  }
}

Form.propTypes = {
  name: PropTypes.string.isRequired,
  formState: PropTypes.object,
  setValidityProperty: PropTypes.func
};



