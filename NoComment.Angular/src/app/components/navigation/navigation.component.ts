import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NoCommentService } from '../../services/noComment.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit , OnDestroy {

  public sub: any;
  public title: string;
  constructor(private router: Router, private activatedRoute: ActivatedRoute, private NoCommentService: NoCommentService) { }

	ngOnInit(): void {
		this.sub = this.activatedRoute.params.subscribe(params => {
      let huh = params;
    });
    
    this.title = "NoComment";
  }

  submit() { 
    // this.NoCommentService.resetData().subscribe(x => {
    //   let reset = x.length;
    // }, (err) => {
    //   console.log(err);
    // });
  }
    
  ngOnDestroy(): void {
    if (this.sub) {
        this.sub.unsubscribe();
    }
  }

}
