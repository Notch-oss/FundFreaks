import { E } from '@angular/cdk/keycodes';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

interface carouselImage {
  imageSrc: string;
  imageAlt: string;
}
@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {
  // @Input() images: carouselImage[]= []
  @Input() indicators = true;
  @Input() controls = true;
  @Input() autoSlide = true;
  @Input() slideInterval = 3000;
  @Input() caption = true;
  isActive = false;
  color = "accent";
  selectedIndex = 0;

  images = [
    {
      imageSrc:
      'assets/images/welcome.jpeg',
      imageAlt: 'nature1',
    },
    {
      imageSrc:
      'assets/images/img2.jpeg',
      imageAlt: 'nature2',
    },
    {
      imageSrc:
      'assets/images/crowdfunding.png',
      imageAlt: 'person1',
    },
    //   imageSrc:
    //   'assets/images/crowdfunding.png',
    //   imageAlt: 'person2',
    // },
  ]

  constructor(
    private _activateRoute:ActivatedRoute,
    private _router:Router) {}

  ngOnInit(): void {
    if(this.autoSlide) {
      this.autoSlideImages()
    }
  }
  autoSlideImages(): void {
    setInterval(() => {
      this.onNextClick();
    }, this.slideInterval);
  }
  selectImage(index: number): void {
    this.selectedIndex = index;
  }

  onPrevClick(): void {
    if(this.selectedIndex === 0) {
      this.selectedIndex = this.images.length -1;
    } else{
      this.selectedIndex--;
    }
  }

  onNextClick(): void {
    if(this.selectedIndex === this.images.length -1) {
      this.selectedIndex = 0;
    } else {
      this.selectedIndex++;
    }
  }
  onClick(){
     this._router.navigate(['/Login'])
    
  }
  onClick1(){
    this._router.navigate(['/Register'])
   
 }
}