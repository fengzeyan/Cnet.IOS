//
//  OSTimesheetViewController.m
//  College Nannies and Tutors Layouts
//
//  Created by kristian.lien on 3/18/14.
//  Copyright (c) 2014 Onsharp. All rights reserved.
//

#import "OSTimesheetViewController.h"

@interface OSTimesheetViewController ()

@end

@implementation OSTimesheetViewController

#pragma mark -
#pragma mark Table View Methods

-(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    UITableViewCell *cell = [UITableViewCell alloc];
    OSTimesheetCell *timesheetCell;
    
    if ([tableView cellForRowAtIndexPath:indexPath] == nil)
    {
        timesheetCell = (OSTimesheetCell *) [tableView dequeueReusableCellWithIdentifier:@"TimesheetCellIdentifier"];
        return timesheetCell;
    }
    
    return cell;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return [testArray count];
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    // Open timesheet here ***
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath
{
    CGFloat cellHeight = 60.0;
    return cellHeight;
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
    
    testArray = [NSArray arrayWithObjects:@"Test 1", @"Test 2", nil]; // Make this non-static ***
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
