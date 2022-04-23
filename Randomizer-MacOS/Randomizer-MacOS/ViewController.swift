//
//  ViewController.swift
//  Randomizer-MacOS
//
//  Created by Leo Dav on 23/04/2022.
//
//

import Cocoa

class ViewController: NSViewController {

    @IBOutlet weak var textBox: NSTextField!
    @IBOutlet weak var resultLabel: NSTextField!
    
    override func viewDidLoad() {
        super.viewDidLoad()
    }

    override var representedObject: Any? {
        didSet {
            // Update the view, if already loaded.
        }
    }

    @IBAction func onGenerate(_ sender: NSButton) {
        print("You Touched the Button")
    }
    
    @IBAction func onValueChanged(_ sender: NSStepper) {
        textBox.integerValue = sender.integerValue
    }
}
