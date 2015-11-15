import React, {Component, PropTypes} from 'react';
import Rx from 'rx';
import FormGroup from '../../common/components/outlets/FormGroup';
import ControlLabel from '../../common/components/outlets/ControlLabel';


export default class FirstName extends Component {

  componentDidMount() {
    this.inputStream = Rx.Observable.fromEvent(document.querySelector("input[name='firstName']"), 'keyup')
      .map(ev => ev.target.value)
      .debounce(500)
      .subscribe(value => this.props.onChange('firstName', value));
  }

  componentWillUnmount() {
    this.inputStream.unsubscribe();
  }

  render() {
    const {firstName} = this.props;
    return (
      <FormGroup>
        <ControlLabel>First name</ControlLabel>
        <input
          required
          minLength={4}
          type="text"
          className="form-control"
          value={firstName}
          name="firstName"
        />

        <span className="help-block">{firstName}</span>
      </FormGroup>
    );
  }
}

FirstName.propTypes = {
  firstName: PropTypes.string,
  onChange: PropTypes.func.isRequired
};
