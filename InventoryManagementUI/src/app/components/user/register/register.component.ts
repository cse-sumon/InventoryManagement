import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  roles:any='';
  
  constructor(
    public service : UserService, 
    private toastr:ToastrService,
    private dialogRef: MatDialogRef<RegisterComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    ) { }

  ngOnInit() {
    this.getRoles();
  }

  getRoles(){
    this.service.getRoles().subscribe(
      (res:any)=>{
        this.roles=res;
        console.log(res);
      },
      err=>{
        console.log(err);
      }
    )
  }

  onNoClick(): void {
    this.service.formModel.reset();
    this.dialogRef.close();
  }

  onClear() {
    this.service.formModel.reset();
  }


  onSubmit(){
    this.service.register().subscribe(
      (res:any)=>{
        if(res.succeeded){
          this.service.formModel.reset();
          this.service.initializeFormModel();
          this.toastr.success('New User Created!','Registration Successfull.');
        }
        else{
          res.errors.forEach(element => {
            switch(element.code){
              case 'DuplicateUserName':
                this.toastr.error('UserName is already taken.','Registration failed');
              break;
              default:
                  this.toastr.error(element.description,'Registration failed.');
              break;
            }
          });
          
        }
      },
      err=>{
        console.log(err);
      }
    )
  }

}
