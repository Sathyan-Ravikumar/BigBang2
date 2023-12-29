import { Component } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

   ngOnInit(): void {
     
 
     const menu: HTMLElement | null = document.querySelector('#menu-icon');
     const navbar: HTMLElement | null = document.querySelector('.navbar');
 
     if (menu && navbar) {
       menu.onclick = () => {
         menu.classList.toggle('bx-x');
         navbar.classList.toggle('open');
       };
     }
    
   }   
 
   
 }
 
