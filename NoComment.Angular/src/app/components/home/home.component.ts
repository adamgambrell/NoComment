import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NoCommentService } from '../../services/noComment.service';
import { ForumsComponent } from '../../components/forums/forums.component'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent implements OnInit, OnDestroy {

  public minutesAgo: number;
  public sub: any;

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private NoCommentService: NoCommentService) { 

  }

  ngOnInit() {

    this.sub = this.activatedRoute.params.subscribe(params => {
      let face = params;
    });

    this.minutesAgo = 18; 

  }

  // submit(){
  //   this.NoCommentService.resetData().subscribe(x => {
  //     let reset = x.length;
  //   },
  //   (err) => {
  //     debugger;
  //   });
  // }

  ngOnDestroy(): void {
    if (this.sub) {
        this.sub.unsubscribe();
    }
  }

}
