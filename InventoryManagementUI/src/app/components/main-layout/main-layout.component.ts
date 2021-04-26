import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { UserService } from 'src/app/shared/user.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.css']
})
export class MainLayoutComponent {
  typesOfShoes: string[] = ['Boots', 'Clogs', 'Loafers', 'Moccasins', 'Sneakers'];
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

    user:any='';

  constructor(private breakpointObserver: BreakpointObserver,
              private service: UserService,
              private router: Router,
              private http:HttpClient) { }

    ngOnInit() {
      this.getUserName();
      // this.http.get('https://localhost:44325/api/ApplicationUser/GetUserProfile').subscribe(
      //   res=>{ this.user=res;
      //   },
      //   error=>{
      //     console.log(error);
      //   }
      // )
    }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['']);
  }

  viewProfile() {
    this.router.navigate(['dashboard/viewProfile']);
  }


  getUserName(){
    this.service.getUserProfile().subscribe(
      res=>{
        this.user=res;
      },
      error=>{
        console.log(error);
      }
    )
  }


}
