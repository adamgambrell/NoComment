import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable, Subscriber } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { HttpService } from './http.service';
import { Forum } from '../models/forum.model';
import { ForumDisplay } from '../models/forum-display.model';
import { ForumDto } from '../models/forum-dto.model';

@Injectable()
export class NoCommentService {
	constructor(private http: HttpService) { }

	public resetData() {
		let url = `/api/inbox`;
		return this.http.get(url).map(res => res.text());
	}

	public getForumDtos() {
		let url = `/api/forum`;
		let face = this.http.get(url).map(res => <ForumDto[]>res.json());
		return face;
	}

	public getForumById(id: string) {
		let url = `/api/forum/${id}`;
		let face = this.http.get(url).map(res => <Forum>res.json());
		return face;
	}
}