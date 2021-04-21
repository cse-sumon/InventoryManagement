import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { single } from 'rxjs/operators';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  
  formModel = {
    UserName:'',
    Password:''
  }
  constructor(private service:UserService, private router:Router, private toastr:ToastrService) { }

  ngOnInit() {
    if(localStorage.getItem('token')!=null)
    this.router.navigateByUrl('/dashboard');

  }

  onSubmit(form:NgForm){
    this.service.login(form.value).subscribe(
      (res:any)=>{
        console.log(res);
        localStorage.setItem('token',res.token);
        this.router.navigateByUrl('/dashboard');
      },
      err=>{
        if(err.status==400)
          this.toastr.error('Incorrect UserName or Password.','Authentication failed.');
          else
          console.log(err);

        
      }
    )
  }




}
