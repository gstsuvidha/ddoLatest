import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TdsService } from '../tds.service';

@Component({
  selector: 'app-tds-print',
  templateUrl: './tds-print.component.html',
  styleUrls: ['./tds-print.component.css']
})
export class TdsPrintComponent implements OnInit {
  id: number;

  constructor(private route: ActivatedRoute, private tdsService: TdsService ) { }

  ngOnInit() {

    this.route.params.subscribe(params => 
      {this.id = params['id'];
            this.getPrint(this.id);
       
    })
  }


  getPrint(id: number)
  {
      this.tdsService.getOne(id).subscribe()
  }

}
