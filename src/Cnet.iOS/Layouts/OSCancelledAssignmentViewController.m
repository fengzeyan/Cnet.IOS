//
//  OSCancelledAssignmentViewController.m
//  College Nannies and Tutors Layouts
//
//  Created by kristian.lien on 3/10/14.
//  Copyright (c) 2014 Onsharp. All rights reserved.
//

#import "OSCancelledAssignmentViewController.h"

@interface OSCancelledAssignmentViewController ()

@end

@implementation OSCancelledAssignmentViewController

#pragma mark -
#pragma mark Table View Methods

-(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    UITableViewCell *cell = [UITableViewCell alloc];
    OSFamilyCell *familyCell;
    OSStartEndCell *startEndCell;
    OSTimesCell *timesCell;
    OSLocationCell *locationCell;
    OSChildrenCell *childrenCell;
    OSInfoCell *infoCell;
    OSDetailsCell *detailsCell;
    
    switch (indexPath.row)
    {
        case 0:
            familyCell = (OSFamilyCell *) [tableView dequeueReusableCellWithIdentifier:@"FamilyCellIdentifier"];
            return familyCell;
            break;
            
        case 1:
            startEndCell = (OSStartEndCell *) [tableView dequeueReusableCellWithIdentifier:@"StartEndCellIdentifier"];
            return startEndCell;
            break;
            
        case 2:
            timesCell = (OSTimesCell *) [tableView dequeueReusableCellWithIdentifier:@"TimesCellIdentifier"];
            return timesCell;
            break;
            
        case 3:
            locationCell = (OSLocationCell *) [tableView dequeueReusableCellWithIdentifier:@"LocationCellIdentifier"];
            return locationCell;
            break;
            
        case 4:
            childrenCell = (OSChildrenCell *) [tableView dequeueReusableCellWithIdentifier:@"ChildrenCellIdentifier"];
            return childrenCell;
            break;
            
        case 5:
            infoCell = (OSInfoCell *) [tableView dequeueReusableCellWithIdentifier:@"InfoCellIdentifier"];
            return infoCell;
            break;
            
        case 6:
            detailsCell = (OSDetailsCell *) [tableView dequeueReusableCellWithIdentifier:@"DetailsCellIdentifier"];
            return detailsCell;
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
    // Do nothing here ***
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
            cellHeight = 75.0;
            break;
            
        case 1:
            cellHeight = 75.0;
            break;
            
        case 2:
            cellHeight = 75.0;
            break;
            
        case 3:
            cellHeight = 50.0;
            break;
            
        case 4:
            cellHeight = 50.0;
            break;
            
        case 5:
            cellHeight = 50.0;
            break;
            
        case 6:
            cellHeight = 250.0; // make this dynamic
            break;
            
        default:
            break;
    }
    
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
    
    testArray = [NSArray arrayWithObjects:@"Test 1", @"Test 2", @"Test 3", @"Test 4", @"Test 5", @"Test 6", @"Test 7", nil]; // Make this non-static ***
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
