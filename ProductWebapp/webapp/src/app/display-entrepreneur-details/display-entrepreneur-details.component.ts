import { Component, OnInit } from '@angular/core';
import { EntDataService } from '../services/ent-data.service';
import { ActivatedRoute } from '@angular/router';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { EntrepreneurProfile } from '../models/entrepreneur-profile';

@Component({
  selector: 'app-display-entrepreneur-details',
  templateUrl: './display-entrepreneur-details.component.html',
  styleUrls: ['./display-entrepreneur-details.component.css']
})
export class DisplayEntrepreneurDetailsComponent implements OnInit {
  users: EntrepreneurProfile[] = [];
  user: EntrepreneurProfile | null = null;
  id: string | undefined | null;
  image: SafeUrl | null = null;
  entId: string | null = null;
  email: string | null = null;
  

  constructor(
    private readonly entData:EntDataService,
    private readonly route: ActivatedRoute,
    private sanitizer: DomSanitizer
  ) { }

  
  ngOnInit(): void {
    this.entId = this.route.snapshot.params['id'];
    
    if (this.entId) {
      this.entData.getOne(this.entId).subscribe({
        next: (data: EntrepreneurProfile) => {
          this.user = data;
          if (this.user?.img) {
            const objectURL = 'data:image/png;base64,' + this.user.img;
            this.image = this.sanitizer.bypassSecurityTrustUrl(objectURL);
          }
        },
        error: (error) => {
          console.error('Error loading entrepreneur details:', error);
        }
      });
    }
  }

  display(): string {
    const temp = localStorage.getItem('email');
    return temp || '';
  }
       }
