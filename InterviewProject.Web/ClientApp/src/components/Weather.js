import React, { Component } from 'react';

export class Weather extends Component {
  static displayName = Weather.name;

  constructor(props) {
    super(props);
    this.state = { 
      postalCode: '55433', 
      forecasts: [], 
      loading: true 
    };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Low Temp (F)</th>
            <th>High Temp (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.date}>
              <td>{forecast.date}</td>
              <td>{forecast.minTemperatureF}</td>
              <td>{forecast.maxTemperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Weather.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        <div className="search">
          <input 
            placeholder="Postal Code"
            //value={this.state.postalCode}
            onChange={(e) => this.tryRepopulate(e.target.value)}
          />
        </div>
        {contents}
      </div>
    );
  }

  tryRepopulate(text) {
    // Only handle US short zip codes for now
    if (text.length == 5) {
      this.setState({ postalCode: text, loading: true }, this.populateWeatherData);
    }
  }

  async populateWeatherData() {
    const response = await fetch(`weather/forecast?postalCode=${this.state.postalCode}`);
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
