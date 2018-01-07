import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable, Subscriber } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { retry } from 'rxjs/operator/retry';

@Injectable()
export class HttpService {
	constructor(private http: Http, private router: Router, private loc: Location) {
	}

	private handleError: ((err: any, errorMsg?: string) => Observable<Response>) =
	((err, errMsg) => {
		if (err.status === 401) {
			console.log(err)

			return new Observable<Response>((subscriber: Subscriber<Response>) => {
				subscriber.complete();
			});
		}
		if (err.status === 403) {
			// redirect you to forbidden
			this.router.navigate(['forbidden']);

			return new Observable<Response>((subscriber: Subscriber<Response>) => {
				subscriber.complete();
			});
		} else {
			
			// display error in toast
			//this.toast.error(err._body, 'Error');

			return new Observable<Response>((subscriber: Subscriber<Response>) => {
				subscriber.error(err);
			});
		}
	}).bind(this);

	public get(url: string, errorMsg?: string) {
		let face = this.http.get(url, { headers: this.JSONHeaders(), body: '' })
			.catch(err => this.handleError(err, errorMsg));
			return face;
	}

	public post(url: string, data: any, errorMsg?: string) {
		return this.http.post(url, JSON.stringify(data), { headers: this.JSONHeaders() })
			.catch(err => this.handleError(err, errorMsg));
	}

	public put(url: string, data: any, errorMsg?: string) {
		return this.http.put(url, JSON.stringify(data), { headers: this.JSONHeaders() })
			.catch(err => this.handleError(err, errorMsg));
	}

	public delete(url: string, errorMsg?: string) {
		return this.http.delete(url, { headers: this.JSONHeaders(), body: '' })
			.catch(err => this.handleError(err, errorMsg));
    }
    
	private JSONHeaders(): Headers {
		var headers = new Headers({
			'Content-Type': 'application/json',
			Accept: 'application/json',
		});

		// let jwt = this.getJwt();
		// if (jwt) {
		// 	headers.append('Authorization', 'Bearer ' + jwt);
		// }
		return headers;
	}
}