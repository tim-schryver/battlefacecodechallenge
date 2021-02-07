import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <h1>Free Insurance Quote Generator</h1>
                <p>Welcome to the Battleface coding challenge, built with React and .NET core:</p>
                <ul>
                    <li>You can use any technology/ies to complete this code challenge.</li>
                    <li>Develop the backend API method call mentioned in the API Documentation.</li>
                    <li>Develop a simple form page that can handle user input, call the API method and then display the results.</li>
                    <li>Some requirements were left open to interpretation to test your ability in making correct assumptions.</li>
                    <li>The format of the deliverable can either be in the form of a compressed file such as a zip file or as a GitHub link.</li>
                    <li>Expected duration of task: 1 to 2 hours.</li>
                </ul>
                <p>The <code>Swagger UI</code> can be found <a href="https://localhost:44361/swagger">here</a> which is used to visualize and interact with the API's resources without having any of the implementation logic in place.</p>
                <p>The <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm test</code> or <code>npm install</code>.</p>
            </div>
        );
    }
}
