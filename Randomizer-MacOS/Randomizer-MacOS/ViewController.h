//
//  ViewController.h
//  Randomizer-MacOS
//
//  Created by Leo Dav on 08/05/22.
//

#import <Cocoa/Cocoa.h>

@interface ViewController : NSViewController

@property unsigned int maxBound;

@property (weak) IBOutlet NSButton* btnGenerate;
@property (weak) IBOutlet NSTextField* labelGenerated;


@end

