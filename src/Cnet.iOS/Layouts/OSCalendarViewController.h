//
//  OSCalendarViewController.h
//  College Nannies and Tutors Layouts
//
//  Created by kristian.lien on 3/14/14.
//  Copyright (c) 2014 Onsharp. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "DSLCalendarView.h"
#import "OSCalendarInfoCell.h"
#import "OSCalendarAppointmentCell.h"

@interface OSCalendarViewController : UIViewController <UITableViewDataSource, UITableViewDelegate, DSLCalendarViewDelegate>
{
    NSArray *testArray;
}

@property (nonatomic, weak) IBOutlet DSLCalendarView *calendarView;

@end
