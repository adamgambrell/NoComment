import { Component, OnInit, OnDestroy } from '@angular/core';
import { Forum } from '../../models/forum.model';
import { Router, ActivatedRoute } from '@angular/router';
import { NoCommentService } from '../../services/noComment.service';
import * as moment from 'moment';
import { ForumDisplay } from '../../models/forum-display.model';
import { ForumDto } from '../../models/forum-dto.model';

@Component({
  selector: 'app-forums',
  templateUrl: './forums.component.html',
  styleUrls: ['./forums.component.scss']
})

export class ForumsComponent implements OnInit {
  public forum: Forum;
  public forumDtos: ForumDto[];
  public forumDisplays: ForumDisplay[];
  public currentDate: string;
  public currentDateString: any;
  public previousDate: string;

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private NoCommentService: NoCommentService) {
    this.forumDisplays = [];
  }

  ngOnInit() {

    // get Dtos
    this.getForumDtos();

  }

  //service calls
  getForumDtos() {
    this.NoCommentService.getForumDtos().subscribe(x => {
      this.forumDtos = x;
      // get forumDisplays array
      this.getForumDisplays();

    }, (err) => {
      console.log(err);
    });
  }

  //private methods
  getForumDisplays() {
    for (let forumDisplayDto of this.forumDtos) {
      let newForumDisplay = new ForumDisplay();

      let dateString = forumDisplayDto.creationDate.toString();
      let date = forumDisplayDto.creationDate;

      var res = dateString.split("T");
      this.currentDate = res[0];
      newForumDisplay.creationDate = date;
      newForumDisplay.subject = forumDisplayDto.subject;
      newForumDisplay.rootEmailId = forumDisplayDto.rootEmailId;
      newForumDisplay.emailCount = forumDisplayDto.emailCount;

      if (this.currentDate == this.previousDate) {
        newForumDisplay.newDay = false;
      } else {
        newForumDisplay.newDay = true;
      }

      this.previousDate = this.currentDate;
      this.forumDisplays.push(newForumDisplay);
    }
  }

  getIncident(rootEmailId: string){
    this.NoCommentService.getForumById(rootEmailId).subscribe(x => {
      this.forum = x;
      var content = this.forum.emails[0];
      debugger;
    }, (err) => {
      console.log(err);
    });
  }

  returnToList() {
    this.forum = null;
  }

  removePreviousEmails(str) {
    var index = str.search(/On.*at.*<.*> wrote:/i);
    str = str.substring(0, index == -1 ? str.length : index);
    return str;
  }



}
