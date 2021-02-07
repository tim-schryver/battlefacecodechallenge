import React, { Component } from 'react';
import { Col, Form, Button } from 'react-bootstrap';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

export class GetQuote extends Component {
    static displayName = GetQuote.name;

    constructor(props) {
        super(props);
        this.state = {
            age: '',
            currency_id: 'EUR',
            start_date: '',
            end_date: ''
        };

        this.handleClick = this.handleClick.bind(this);
    }

    async handleClick() {
        //event.preventDefault();
        const loginResponse = await fetch('registration/login');
        const jwt = await loginResponse.json();

        const requestOptions = {
            method: 'POST',
            headers:
            {
                'Content-Type': 'application/json',
                'authorization': 'bearer ' + jwt.token
            },
            body: JSON.stringify(
                {
                    age: this.state.age,
                    currency_id: this.state.currency_id,
                    start_date: this.state.start_date,
                    end_date: this.state.end_date
                })
        };
        const response = await fetch('quotes/quotation', requestOptions);

        if (response.status === 400) {
            var result =  await response.text();
            //alert(result);
            toast(result);
            //console.log(response.json());
        }
        //const data = await response.json();


        //this.setState({ forecasts: data, loading: false });
    }

    render() {
        return (
            <div>
                <ToastContainer />
                <h1 id="tabelLabel" >Get a Quote fast</h1>
                <Form>
                    <Form.Row>
                        <Col xs={4}>
                            <Form.Label>Enter comma delimited list of travelers' ages</Form.Label>
                            <Form.Label>(e.g. "28,35")</Form.Label>
                            <Form.Group controlId="formAge" >
                                <Form.Control required placeholder="Enter one or more traveler age" value={this.state.age}
                                    onChange={e => this.setState({ age: e.target.value })}/>
                            </Form.Group>
                        </Col>
                    </Form.Row>
                    <Form.Row>
                        <Col xs={4}>
                            <Form.Group controlId="formCurrencySelect">
                                <Form.Label>Currency Type</Form.Label>
                                <Form.Control as="select"  value={this.state.currency_id} 
                                    onChange={e => this.setState({ currency_id: e.target.value })}>
                                    <option value='EUR'>EUR</option>
                                    <option value='GBP'>GBP</option>
                                    <option value='USD'>USD</option>
                                </Form.Control>
                            </Form.Group>
                        </Col>
                    </Form.Row>
                    <Form.Row>
                        <Col xs={4}>
                            <Form.Group controlId="formStartDate">
                                <Form.Label>Start Date</Form.Label>
                                <Form.Control required type="date" placeholder="Start Date" value={this.state.start_date}
                                    onChange={e => this.setState({ start_date: e.target.value })}/>
                            </Form.Group>
                        </Col>
                        <Col xs={4}>
                            <Form.Group controlId="formEndDate">
                                <Form.Label>End Date</Form.Label>
                                <Form.Control required type="date" placeholder="End Date" value={this.state.end_date}
                                    onChange={e => this.setState({ end_date: e.target.value })}/>
                            </Form.Group>
                        </Col>
                    </Form.Row>
                    <Button variant="primary" onClick={this.handleClick}>
                        Get Quote
                </Button>
                </Form>
            </div>
        );
    }
}
