//
//  OSCalendarViewController.m
//  College Nannies and Tutors Layouts
//
//  Created by kristian.lien on 3/14/14.
//  Copyright (c) 2014 Onsharp. All rights reserved.
//

#import "OSCalendarViewController.h"

@interface OSCalendarViewController ()

@end

@implementation OSCalendarViewController

#pragma mark -
#pragma mark Table View Methods

-(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    UITableViewCell *cell = [UITableViewCell alloc];
    OSCalendarInfoCell *infoCell;
    OSCalendarAppointmentCell *appointmentCell;
    
    switch (indexPath.row)
    {
        case 0:
            infoCell = (OSCalendarInfoCell *) [tableView dequeueReusableCellWithIdentifier:@"CalendarInfoCellIdentifier"];
            return infoCell;
            break;
            
        case 1:
            appointmentCell = (OSCalendarAppointmentCell *) [tableView dequeueReusableCellWithIdentifier:@"AppointmentCellIdentifier"];
            return appointmentCell;
            break;
            
        case 2:
            appointmentCell = (OSCalendarAppointmentCell *) [tableView dequeueReusableCellWithIdentifier:@"AppointmentCellIdentifier"];
            return appointmentCell;
            break;
            
        case 3:
            appointmentCell = (OSCalendarAppointmentCell *) [tableView dequeueReusableCellWithIdentifier:@"AppointmentCellIdentifier"];
            return appointmentCell;
            break;
            
        default:
            break;
    }
    
    return cell;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return [testArray count];
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    // Open assignment here ***
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath
{
    
    /*NSDictionary *d=(NSDictionary *)[self.menuArray objectAtIndex:indexPath.section];
     NSString *label =  [d valueForKey:@"Description"];
     CGSize stringSize = [label sizeWithFont:[UIFont boldSystemFontOfSize:15]
     constrainedToSize:CGSizeMake(320, 9999)
     lineBreakMode:UILineBreakModeWordWrap];*/
    CGFloat cellHeight = 0.0;
    
    switch (indexPath.row)
    {
        case 0:
            cellHeight = 50.0;
            break;
            
        case 1:
            cellHeight = 50.0;
            break;
            
        case 2:
            cellHeight = 50.0;
            break;
            
        case 3:
            cellHeight = 50.0;
            break;
            
        default:
            break;
    }
    
    return cellHeight;
    
}

#pragma mark -
#pragma mark DSLCalendarViewDelegate methods

- (void)calendarView:(DSLCalendarView *)calendarView didSelectRange:(DSLCalendarRange *)range
{
    if (range != nil) {
        NSLog( @"Selected %ld/%ld - %ld/%ld", (long)range.startDay.day, (long)range.startDay.month, (long)range.endDay.day, (long)range.endDay.month);
    }
    else {
        NSLog( @"No selection" );
    }
}

- (DSLCalendarRange*)calendarView:(DSLCalendarView *)calendarView didDragToDay:(NSDateComponents *)day selectingRange:(DSLCalendarRange *)range {
    if (NO) { // Only select a single day
        return [[DSLCalendarRange alloc] initWithStartDay:day endDay:day];
    }
    else if (NO) { // Don't allow selections before today
        NSDateComponents *today = [[NSDate date] dslCalendarView_dayWithCalendar:calendarView.visibleMonth.calendar];
        
        NSDateComponents *startDate = range.startDay;
        NSDateComponents *endDate = range.endDay;
        
        if ([self day:startDate isBeforeDay:today] && [self day:endDate isBeforeDay:today]) {
            return nil;
        }
        else {
            if ([self day:startDate isBeforeDay:today]) {
                startDate = [today copy];
            }
            if ([self day:endDate isBeforeDay:today]) {
                endDate = [today copy];
            }
            
            return [[DSLCalendarRange alloc] initWithStartDay:startDate endDay:endDate];
        }
    }
    
    return range;
}

- (void)calendarView:(DSLCalendarView *)calendarView willChangeToVisibleMonth:(NSDateComponents *)month duration:(NSTimeInterval)duration {
    NSLog(@"Will show %@ in %.3f seconds", month, duration);
}

- (void)calendarView:(DSLCalendarView *)calendarView didChangeToVisibleMonth:(NSDateComponents *)month {
    NSLog(@"Now showing %@", month);
}

- (BOOL)day:(NSDateComponents*)day1 isBeforeDay:(NSDateComponents*)day2 {
    return ([day1.date compare:day2.date] == NSOrderedAscending);
}

#pragma mark -
#pragma mark Controller Methods

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view.
    self.calendarView.delegate = self;
    
    testArray = [NSArray arrayWithObjects:@"Test 1", @"Test 2", @"Test 3", @"Test 4", nil]; // Make this non-static ***
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
