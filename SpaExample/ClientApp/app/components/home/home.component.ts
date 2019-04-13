import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    public standByCall: StandByCallsResponse | undefined;
    public totalCalls = 0;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
            this.standByCall = result.json() as StandByCallsResponse;
            this.totalCalls = this.standByCall.total;
        }, error => console.error(error));
    }
}

interface CallResponseDetails {
    source: string;
    duration: Date;
}

interface StandByCallsResponse {
    total: number;
    calls: CallResponseDetails[]; 
}
