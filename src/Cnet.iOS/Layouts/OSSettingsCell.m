//
//  OSSettingsCell.m
//  College Nannies and Tutors Layouts
//
//  Created by kristian.lien on 3/26/14.
//  Copyright (c) 2014 Onsharp. All rights reserved.
//

#import "OSSettingsCell.h"

@implementation OSSettingsCell

@synthesize mainLabel;

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
