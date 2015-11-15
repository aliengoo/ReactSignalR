import React, {Component, PropTypes} from 'react';
import {connect} from 'react-redux';
import Rx from 'rx';

import Form from '../common/components/outlets/Form';
import FirstName from './components/FirstName';

// actions
import {invoke as invokeSetCustomerPropertyAction} from './actions/setCustomerPropertyAction';
import {invoke as invokeSetValidityPropertyAction} from './actions/setValidityPropertyAction';

export default class Customer extends Component {

  constructor() {
    super();
    this.setValidityProperty = this.setValidityProperty.bind(this);
    this.onChange = this.onChange.bind(this);
  }

  setValidityProperty(name, validity) {
    this.props.dispatch(invokeSetValidityPropertyAction(name, validity));
  }

  onChange(name, value) {
    this.props.dispatch(invokeSetCustomerPropertyAction(name, value));
  }

  render() {
    const {customer} = this.props;

    return (
      <div className="container">
        <header>
          <h1>Customer</h1>
        </header>

        <Form name="customerForm" setValidityProperty={this.setValidityProperty}>
          <FirstName firstName={customer.firstName} onChange={this.onChange}/>
        </Form>

         <pre>
          {JSON.stringify(customer)}
        </pre>
      </div>);
  }
}

function select(state) {
  return {
    customer: state.customer
  };
}

export default connect(select)(Customer);