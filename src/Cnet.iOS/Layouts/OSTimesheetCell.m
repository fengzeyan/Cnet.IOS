//
//  OSTimesheetCell.m
//  College Nannies and Tutors Layouts
//
//  Created by kristian.lien on 3/18/14.
//  Copyright (c) 2014 Onsharp. All rights reserved.
//

#import "OSTimesheetCell.h"

@implementation OSTimesheetCell

- (id)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier
{
    self = [super initWithStyle:style reuseIdentifier:reuseIdentifier];
    if (self) {
        // Initialization code
    }
    return self;
}

- (void)awakeFromNib
{
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated
{
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
