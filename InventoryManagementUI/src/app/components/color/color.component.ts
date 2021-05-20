import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { HttpEventType, HttpClient, HttpHeaders } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
import { stringify } from '@angular/compiler/src/util';
@Component({
  selector: 'app-color',
  templateUrl: './color.component.html',
  styleUrls: ['./color.component.css']
})
export class ColorComponent implements OnInit {

  public progress: number;
  public message: string;
  categoryId:number=1;

  selectedFile: File = null;
 //newBlogForm: FormGroup;

  @Output() public onUploadFinished = new EventEmitter();
  constructor(private http: HttpClient) { }

  newBlogForm = new FormGroup({
    Name: new FormControl(null),
    TileImage: new FormControl(null)
  });

  ngOnInit(): void {
//     var formData = new FormData();
//     formData.append('name', true);
// formData.append('name', 74);
// formData.append('name', 'John');

// console.log(formData.getAll('name')); // ["true", "74", "John"]
   
  }

  onSelectFile(fileInput: any) {
    this.selectedFile = <File>fileInput.target.files[0];
    console.log(this.selectedFile);
  }

  onSubmit(data) {
  
    const formData = new FormData();
    formData.append('id',9);
    formData.append('categoryId',2);
    formData.append('subCategoryId',3);
    formData.append('name', 'jamdani cutton');
    formData.append('description', 'tangail cutton jamdani');
    formData.append('purchasePrice', 900);
    formData.append('salePrice', 1500);
    formData.append('isActive', true);
    formData.append('iformFile', this.selectedFile, this.selectedFile.name);
    formData.append('picture', 'E:\\Asp.Net Core Web Api\\InventoryManagement\\WebApi\\Uploads/Product_Images\\20151104_180036_e8ae.jpg');
   



    this.http.put('https://localhost:44325/api/Product/9', formData)
    .subscribe(res => {
  
      alert('Uploaded!!');
    });
  
    this.newBlogForm.reset();
  }



  public uploadFile = (files:Blob) => {
    return;
   
    if (files.size === 0) {
      return;
    }
    let fileToUpload:File = <File>files[0];
    var formData = new FormData();
    formData.append('file',fileToUpload, fileToUpload.name);

    
  

    
   // return;

    let body={
      categoryId:1,
      subCategoryId:2,
      name :"jamdani silk",
       description:"tangail silk jamdani",
       purchasePrice:800,
       salePrice:1000,
       iFormFile:fileToUpload,
       isActive:true
    }
    console.log(body);
    //const headers = new HttpHeaders().append('Content-Disposition', 'multipart/form-data');
    this.http.post('https://localhost:44325/api/Product', formData)
      .subscribe(res => 
        {
          console.log(res);
        },
        error=>{
          console.log(error);
        }
      );
  }


  imageToBase64(event) {
    let me = this;
    let file = <File>event[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
      //me.modelvalue = reader.result;
      console.log(reader.result);
    };
    reader.onerror = function (error) {
      console.log('Error: ', error);
    };
 }

}
